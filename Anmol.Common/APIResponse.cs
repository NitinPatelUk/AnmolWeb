using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Common
{
    #region Common

    /// <summary>
    /// This class will use during communication with API to get response
    /// </summary>
    public class BaseApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiResponse" /> class.
        /// </summary>
        public BaseApiResponse()
        {
            this.Message = new List<string> { };
        }

        /// <summary>
        /// Gets or sets a value indicating whether response is success or fail
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public IList<string> Message { get; set; }
    }

    /// <summary>
    /// This class will use to transfer data during communication with API
    /// </summary>
    /// <typeparam name="T">Entity class object</typeparam>
    public class ApiResponse<T> : BaseApiResponse
    {
        /// <summary>
        /// Gets or sets list of data
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public virtual IList<T> Data { get; set; }
    }

    /// <summary>
    /// This class will use to get response from insert/update operation of Provider
    /// </summary>
    public class ApiMissingTitleResult : BaseApiResponse
    {
        /// <summary>
        /// Gets or sets the provider identifier.
        /// </summary>
        /// <value>
        /// The provider identifier.
        /// </value>
        public long ProviderID { get; set; }

        /// <summary>
        /// Gets or sets TitleID
        /// </summary>
        /// <value>
        /// The title identifier.
        /// </value>
        public long TitleID { get; set; }
    }


    /// <summary>
    /// This class will use get response
    /// </summary>
    /// <typeparam name="T">Entity class object</typeparam>
    public class ApiPostResponse<T> : BaseApiResponse
    {
        /// <summary>
        /// Gets or sets data
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public virtual T Data { get; set; }
    }

    #endregion

    public class Response
    {
        /// <summary>
        /// Gets or sets a value indicating whether response is success or fail
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the taid.
        /// </summary>
        /// <value>
        /// The taid.
        /// </value>
        public long TAID { get; set; }
    }

    public class GetByteArray : BaseApiResponse
    {
        /// <summary>
        /// Gets or sets the byte information.
        /// </summary>
        /// <value>
        /// The byte information.
        /// </value>
        public byte[] ByteInfo { get; set; }
    }

}

