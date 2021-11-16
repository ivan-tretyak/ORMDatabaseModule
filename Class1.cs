using Microsoft.EntityFrameworkCore;
using System;

namespace ORMDatabaseModule
{
    public interface ITable
    {

    }

    public class DatabaseContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<MetaData> MetaDatas { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<AlbumContext> AlbumContexts { get; set; }
        public string DbPath { get; private set; }
        public DatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            string v = $"{path}{System.IO.Path.DirectorySeparatorChar}photos.db";
            DbPath = v;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    }

    [Index(nameof(Name), IsUnique = true)]
    public class Album : ITable
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string DateCreation { get; set; }
    }
    public class MetaData : ITable
    {
        public int MetadataId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Orientation { get; set; }
        public float FocusLength { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Flash { get; set; }
        public string DateCreation { get; set; }
    }
    public class Photo : ITable
    {
        public int PhotoId { get; set; }
        public string Path { get; set; }
        public int Exist { get; set; }
        public MetaData MetaData { get; set; }
        public int MetaDataId { get; set; }
    }
    public class AlbumContext : ITable
    {
        public int AlbumContextId { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
    }
}
