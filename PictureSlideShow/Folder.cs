using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PictureSlideShow
{
    class Folder
    {
        public readonly string[] _filenames;        
        
        public int CurrentFileIndex {get; set;}

        public int Length => _filenames.Length;

        public bool IsFirstImage => CurrentFileIndex - 1 < 0;

        public bool IsFinalImage => CurrentFileIndex + 1 >= Length;

        //Constructor
        public Folder(string[] fileNames)
        {
            _filenames = fileNames;
        }

        //Return the file path string at the current file index.
        public string GetFileName()
        {
            return _filenames[CurrentFileIndex];
        }
    }
}
