﻿using System;
﻿using System.IO;
﻿using System.Threading.Tasks;

﻿namespace SHT.Application.Files.Contracts
{
    public class DownloadFileDto
    {
        public Func<Task<Stream>> StreamAccessor { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }
    }
}
