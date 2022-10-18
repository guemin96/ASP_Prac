using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ModuleA;
using ModuleB;

namespace ConsoleApp1 {
    internal class Program {
        //private TestModuleA _module;
        private TestModuleB _module;
        public Program(TestModuleB module) {
            _module = module; 
            //생성자에서만 객체 생성
        }
        static void Main(string[] args) {
        
        }
        public void test1() {
            _module.Test2();
        }
        public void test2() {
        }
    }
}
