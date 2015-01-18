using System;
using InOut.Utils;

namespace InOut.Entity
{
    [Serializable]
    public class MyFile
    {
        [Alias("isFile")]
		public bool IsFile { get; set; }
        [Alias("isDir")]
		public bool IsDir { get; set; }
        [Alias("lastModif")]
		public long LastModif { get; set; }
        [Alias("length")]
		public long Length { get; set; }
        [Alias("name")]
		public string Name { get; set; }
        [Alias("r")]
		public bool R { get; set; }
        [Alias("w")]
		public bool W { get; set; }
        [Alias("hidden")]
		public bool Hidden { get; set; }
        [Alias("path")]
		public string Path { get; set; }
		[Alias("list")]
		public MyFile[] List { get; set; }

    }
}
