﻿using com.xxl.job.core.biz.model;
using com.xxl.job.core.rpc.codec;
using hessiancsharp.io;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using XxlJob.Core.RPC;

namespace XxlJob.Test
{
    public class ThreadTest
    {
        private readonly ITestOutputHelper output;
        private readonly AutoResetEvent e = new AutoResetEvent(false);

        public ThreadTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ThreadInterruptTest()
        {
            Thread t1 = new Thread(Run);
            t1.Start();
            Thread.Sleep(1000 * 3);
            output.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + t1.ThreadState.ToString());
            t1.Interrupt();
            output.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + t1.ThreadState.ToString());
            t1.Interrupt();
            Thread.Sleep(1000 * 3);
            return;
            output.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + "interruput at " + DateTime.Now.Ticks.ToString());
            t1.Interrupt();
            output.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + t1.ThreadState.ToString());
            Thread.Sleep(1000 * 3);
        }

        private void Run()
        {
            output.WriteLine(Guid.NewGuid().ToString());
            
            try
            {
                //e.WaitOne(TimeSpan.FromSeconds(10));

                while (false)
                {
                    output.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + DateTime.Now.Ticks.ToString());
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                output.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + ex.ToString());
            }
        }
    }
}