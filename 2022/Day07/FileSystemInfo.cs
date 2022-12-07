using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public abstract class FileSystemInfoBase
    {
        public string Name { get; set; }

        public abstract int Size { get; }
    }

    public class DirectoryInfo : FileSystemInfoBase
    {
        public DirectoryInfo()
        {
            Content = new List<FileSystemInfoBase>();
        }

        public DirectoryInfo Parent { get; set; }

        public List<FileSystemInfoBase> Content { get; set; }

        public IEnumerable<FileSystemInfoBase> FlattenItems()
        {
            yield return this;
            foreach (FileSystemInfoBase item in Content.OfType<DirectoryInfo>().SelectMany((DirectoryInfo d) => d.FlattenItems()))
            {
                yield return item;
            }
        }

        public override int Size => Content.Sum(x => x.Size);
    }

    public class FileInfo : FileSystemInfoBase 
    {
        public FileInfo(string name, int size)
        {
            Name = name;
            _size = size;
        }

        private int _size;

        public override int Size => _size;        
    }
}
