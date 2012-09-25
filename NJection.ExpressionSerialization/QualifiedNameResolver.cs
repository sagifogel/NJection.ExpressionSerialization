using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NJection.Extensions;

namespace NJection.ExpressionSerialization
{
    public class QualifiedNameResolver
    {
        private StringBuilder _builder = null;
        private static readonly Assembly _executingAssembly = null;

        static QualifiedNameResolver() {
            _executingAssembly = Assembly.GetExecutingAssembly();
        }

        public string Resolve(Type type) {
            if (!NeedsQualification(type)) {
                return type.FullName;
            }

            _builder = new StringBuilder();
            ResolveType(type);

            return _builder.ToString();
        }

        private void ResolveType(Type type) {
            if (!NeedsQualification(type)) {
                _builder.Append(type.FullName);
            }
            else if (type.IsGenericType) {
                ResolveGenricDefinition(type);
            }
            else {
                ResolveQualification(type);
            }
        }

        private void ResolveArgumentType(Type type, int current, int length) {
            ResolveType(type);

            if (current != length) {
                _builder.Append(", ");
            }
        }

        private void ResolveGenricDefinition(Type type) {
            var types = type.GetGenericArguments();
            var length = types.Length - 1;

            _builder.AppendFormat("{0}[", type.FullName.Split('[')[0]);

            types.ForEach((a, i) => {
                if (NeedsQualification(a)) {
                    _builder.Append("[");
                    ResolveArgumentType(a, i, length);
                    _builder.Append("]");
                }
                else {
                    ResolveArgumentType(a, i, length);
                }
            });

            _builder.Append("]");
        }

        private void ResolveQualification(Type type) {
            _builder.AppendFormat("{0}, {1}", type.FullName, Path.GetFileNameWithoutExtension(type.Module.Name));
        }

        public bool NeedsQualification(Type type) {
            return type.IsGenericType ||
                   !(type.Assembly.GetName().Name.Equals("mscorlib") || _executingAssembly.Equals(type.Assembly));
        }
    }
}
