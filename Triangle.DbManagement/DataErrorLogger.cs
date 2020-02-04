using System;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace Triangle.DbManagement
{
    /// <summary>
    /// Data Error Logger
    /// </summary>
    public static class DataErrorLogger
    {
        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="errorInfo">The exception to log.</param>
        public static void LogError(Exception errorInfo)
        {
            LogError(errorInfo, string.Empty);
        }

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="errorInfo">The exception to log.</param>
        /// <param name="comments">Comments pertaining to the error</param>
        public static void LogError(Exception errorInfo, string comments)
        {
            string whichSiteName = "INTERNAL";

            try
            {
                whichSiteName = Convert.ToString(ConfigurationManager.AppSettings["WebSiteType"], CultureInfo.CurrentCulture);
                if (string.IsNullOrEmpty(whichSiteName))
                {
                    whichSiteName = "INTERNAL";
                }
            }
            catch (Exception)
            {
                whichSiteName = Convert.ToString(ConfigurationManager.AppSettings["WebSiteType"], CultureInfo.CurrentCulture);
                if (string.IsNullOrEmpty(whichSiteName))
                {
                    whichSiteName = "INTERNAL";
                }
            }

            var errorMessage = ExtractErrorDetails(errorInfo, comments);

            StringBuilder subjectLine = new StringBuilder();

            subjectLine.Append("_500 - (");
            subjectLine.Append(System.Environment.MachineName);
            subjectLine.Append(") - ");

            subjectLine.Append(" - ");
            subjectLine.Append(errorInfo.Message);
            subjectLine.Append(")");

            //SiteErrorLogDB.SaveErrorDetails(whichSiteName, "NONE", "NONE", errorMessage.ToString(), subjectLine.ToString(), "500", comments);
        }

        /// <summary>
        /// Extracts the error details.
        /// </summary>
        /// <param name="errorInfo">The error info.</param>
        /// <param name="comments">The comments.</param>
        /// <returns>StringBuilder with exception details</returns>
        internal static StringBuilder ExtractErrorDetails(Exception errorInfo, string comments)
        {
            StringBuilder errorBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(comments))
            {
                errorBuilder.AppendLine("Comment");
                errorBuilder.AppendLine("---------------");
                errorBuilder.Append(comments);
                errorBuilder.Append(System.Environment.NewLine);
                errorBuilder.Append(System.Environment.NewLine);
            }

            errorBuilder.AppendLine("Error Details:");
            errorBuilder.AppendLine("--------------");
            errorBuilder.AppendLine("Error Message: " + errorInfo.Message);
            errorBuilder.AppendLine("Error Source: " + errorInfo.Source);
            errorBuilder.AppendLine("Error Target Site: " + errorInfo.TargetSite);
            errorBuilder.Append(System.Environment.NewLine);

            errorBuilder.AppendLine("Exception Stack Trace:");
            errorBuilder.AppendLine("----------------------");
            errorBuilder.AppendLine(errorInfo.StackTrace);
            errorBuilder.Append(System.Environment.NewLine);

            var innerException = errorInfo.InnerException;
            while (innerException != null)
            {
                errorBuilder.AppendLine("Inner Exception - Error Details:");
                errorBuilder.AppendLine("--------------");
                errorBuilder.AppendLine("Error Message: " + innerException.Message);
                errorBuilder.AppendLine("Error Source: " + innerException.Source);
                errorBuilder.AppendLine("Error Target Site: " + innerException.TargetSite);
                errorBuilder.Append(System.Environment.NewLine);

                errorBuilder.AppendLine("Inner Exception - Exception Stack Trace:");
                errorBuilder.AppendLine("----------------------");
                errorBuilder.AppendLine(innerException.StackTrace);
                errorBuilder.Append(System.Environment.NewLine);

                innerException = innerException.InnerException;
            }

            errorBuilder.Append(System.Environment.NewLine);

            return errorBuilder;
        }
    }
}
