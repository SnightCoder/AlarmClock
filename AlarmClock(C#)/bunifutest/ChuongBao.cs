using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bunifutest
{
    class ChuongBao
    {
        int id;
        String name,path;
        int status, run;

        public ChuongBao(int id, string name, string path, int status, int run)
        {
            this.id = id;
            this.name = name;
            this.path = path;
            this.status = status;
            this.run = run;
        }

        public int Status { get => status; set => status = value; }
        public int Run { get => run; set => run = value; }
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public int Id { get => id; set => id = value; }
    }
}
