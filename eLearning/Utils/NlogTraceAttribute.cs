using NLog;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Utils
{
    [Serializable]
    public class NlogTraceAttribute : OnMethodBoundaryAspect
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>  
        /// On Method Entry  
        /// </summary>  
        /// <param name="args"></param>  
        public override void OnEntry(MethodExecutionArgs args)
        {
            Logger.Info($"OnEntry : {(args.Method != null ? args.Method.Name : "")}");

            string className = string.Empty, methodName = string.Empty, arguments = string.Empty;
            if (args.Method != null)
                if (args.Method.DeclaringType != null)
                    className = $"{args.Method.DeclaringType.Namespace}.{args.Method.DeclaringType.Name}";
            if (args.Method != null) methodName = args.Method.Name;
            if (args.Arguments != null)
                arguments = args.Arguments.ToString();

            Logger.Info($"className: {className}; methodName:{methodName};arguments:{arguments}");
        }

        /// <summary>  
        /// On Method success  
        /// </summary>  
        /// <param name="args"></param>  
        public override void OnSuccess(MethodExecutionArgs args)
        {
            Logger.Info($"OnSuccess : {(args.Method != null ? args.Method.Name : "")}");
            var returnValue = args.ReturnValue;
            Logger.Info($"ReturnValue : {returnValue}");
        }


        /// <summary>  
        /// On Method Exception  
        /// </summary>  
        /// <param name="args"></param>  
        public override void OnException(MethodExecutionArgs args)
        {
            if (args.Exception != null)
                Logger.Info($"OnException : {(!string.IsNullOrEmpty(args.Exception.Message) ? args.Exception.Message : "")}");


            var Message = args.Exception.Message;
            var StackTrace = args.Exception.StackTrace;

            Logger.Info($"Application has got exception in method-{args.Method.Name} and message is {Message}");

            // or you can send email notification         
        }

        /// <summary>  
        /// On Method Exit  
        /// </summary>  
        /// <param name="args"></param>  
        public override void OnExit(MethodExecutionArgs args)
        {
        }
    }
}
