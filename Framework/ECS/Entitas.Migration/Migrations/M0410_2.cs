﻿using System.IO;

namespace QFramework.Migration
{

    public class M0410_2 : IMigration
    {

        public string version
        {
            get { return "0.41.0-2"; }
        }

        public string workingDirectory
        {
            get { return "where generated files are located"; }
        }

        public string description
        {
            get { return "Adding temporary Feature class"; }
        }

        public MigrationFile[] Migrate(string path)
        {
            const string featureClass =
                @"namespace QFramework {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    public class Feature : QFramework.VisualDebugging.Unity.DebugSystems {

        public Feature(string name) : base(name) {
        }

        public Feature() : base(true) {
            var typeName = QFramework.TypeSerializationExtension.ToCompilableString(GetType());
            var shortType = QFramework.TypeSerializationExtension.ShortTypeName(typeName);
            initialize(toSpacedCamelCase(shortType));
        }

        static string toSpacedCamelCase(string text) {
            var sb = new System.Text.StringBuilder(text.Length * 2);
            sb.Append(char.ToUpper(text[0]));
            for (int i = 1; i < text.Length; i++) {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ') {
                    sb.Append(' ');
                }
                sb.Append(text[i]);
            }

            return sb.ToString();
        }
    }

#else

    public class Feature : QFramework.Systems {

        public Feature(string name) {
        }

        public Feature() {
        }
    }

#endif

}";

            return new[] {new MigrationFile(path + Path.DirectorySeparatorChar + "Feature.cs", featureClass)};
        }
    }
}