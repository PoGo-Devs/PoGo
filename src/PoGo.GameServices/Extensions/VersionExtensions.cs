using Windows.ApplicationModel;

namespace System
{
    public static class VersionExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static PackageVersion ToPackageVersion(this Version version)
        {
            if (version == null) throw new ArgumentNullException("version");
            return new PackageVersion
            {
                Major = Convert.ToUInt16(version.Major),
                Minor = Convert.ToUInt16(version.Minor),
                Build = Convert.ToUInt16(version.Build)
            };
        }

    }

}