//ORM module. This module simplifies interaction with the database
//Copyright (C) 2021 Ivan Tretyak Nickolaevich
//This program is free software; you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation; either version 2 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License along
//with this program; if not, write to the Free Software Foundation, Inc.,
//51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA

using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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
            RegistryKey currentUser = Registry.CurrentUser;
            RegistryKey registry = currentUser.OpenSubKey("appPhotoOrginizer");
            string pathToSearch = registry.GetValue("FolderSync").ToString();

            if (pathToSearch is null)
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                pathToSearch = Environment.GetFolderPath(folder);
            }

           
            string v = $"{pathToSearch}{System.IO.Path.DirectorySeparatorChar}photos.db";
            DbPath = v;
        }

        public DatabaseContext(string path)
        {
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
