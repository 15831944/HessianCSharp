using System;
using System.Collections.Generic;
using System.IO;

namespace HessianCSharp.io
{
    /// <summary>
    /// Summary description for CDecimalDeserializer.
    /// </summary>
    public class CDecimalSerializer : AbstractSerializer
    {
        public const string PROT_DECIMAL_TYPE = "decimal";

        /// <summary>
        /// Serialiaztion of objects
        /// </summary>
        /// <param name="objData">Object to serialize</param>
        /// <param name="abstractHessianOutput">HessianOutput - Instance</param>
        public override void WriteObject(object objData, AbstractHessianOutput abstractHessianOutput)
        {
            if (abstractHessianOutput.AddRef(objData))
                return;
            if (objData == null)
                abstractHessianOutput.WriteNull();
            else
            {
                int iref = abstractHessianOutput.WriteObjectBegin(PROT_DECIMAL_TYPE);

                if (iref < -1)
                {
                    abstractHessianOutput.WriteString("value");
                    abstractHessianOutput.WriteString(objData.ToString());
                    abstractHessianOutput.WriteMapEnd();
                }
                else
                {
                    if (iref == -1)
                    {
                        abstractHessianOutput.WriteClassFieldLength(1);
                        abstractHessianOutput.WriteString("value");
                        abstractHessianOutput.WriteObjectBegin(PROT_DECIMAL_TYPE);
                    }

                    abstractHessianOutput.WriteString(objData.ToString());
                }
            }
        }
    }
}
