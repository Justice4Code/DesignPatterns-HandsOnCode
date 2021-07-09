using System;
using System.Collections.Generic;

namespace DP.Singleton
{
    /// <summary>
    /// Singleton Class
    /// </summary>
    public class LoadBalancer
    {
        //Singleton object
        LoadBalancer instance;
        //Contains the definations of the servers.
        List<string> servers = new List<string>();
        //Random object for simplify the process. 
        Random random = new Random();

        //Lock synchronization object
        private static object locker = new object();

        // Constructor is protected and accessible within loadbalancer class only or types derived from the loadbalancer class. 
        protected LoadBalancer()
        {
            servers.Add("Localhost:4040");
            servers.Add("Localhost:4041");
            servers.Add("Localhost:4042");
            servers.Add("Localhost:4043");
            servers.Add("Localhost:4044");
            servers.Add("Localhost:4045");
        }

        /// <summary>
        /// Simple Singleton
        /// </summary>
        /// <returns></returns>
        public LoadBalancer GetLoadBalancer()
        {
            if (instance == null)
            {
                instance = new LoadBalancer();
            }

            return instance;
        }

        /// <summary>
        /// Support multithreaded applications through "double checked locking" pattern which (once the instance exists) avoids locking each time the method is invoked. 
        /// </summary>
        /// <returns></returns>
        public LoadBalancer GetLoadBalancerMultiThread()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LoadBalancer();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Another way to simply make a singleton object
        /// </summary>
        public LoadBalancer SingletonObject
        {
            get
            {
                if(instance == null)
                {
                    instance = new LoadBalancer();
                }

                return instance; 
            }
        }

        public string Server
        {
            get
            {
                int index = random.Next(servers.Count);
                return servers[index].ToString(); 
            }
        }
    }
}
