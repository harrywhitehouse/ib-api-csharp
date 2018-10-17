using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;


namespace IBePostage
{
    public class ApiException : Exception
    {
        public int HttpStatusCode { get; set; }
        public string ErrorCode { get; set; }

        public ApiException(int httpStatusCode, ApiError apiError) : base(apiError.message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.ErrorCode = apiError.code;
        }
    }

    public class ToAddress
    {
        public string first_name { get; set; }
        public object middle_name { get; set; }
        public string last_name { get; set; }
        public string company_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public object sms { get; set; }
        public string country_code { get; set; }
    }

    public class FromAddress
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
    }


    public class ReportFromAddress
    {
        public string first_name { get; set; }
        public object middle_name { get; set; }
        public string last_name { get; set; }
        public string company_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public object sms { get; set; }
        public string iso_country_code { get; set; }
    }

    public class ReportToAddress
    {
        public string first_name { get; set; }
        public object middle_name { get; set; }
        public string last_name { get; set; }
        public string company_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public object sms { get; set; }
        public string iso_country_code { get; set; }
    }

    public class ReportUsps
    {
        public string mail_class { get; set; }
        public string pricing { get; set; }
        public IList<string> tracking_numbers { get; set; }
    }

    public class LabelReport
    {
        public string status { get; set; }
        public ReportFromAddress from_address { get; set; }
        public ReportToAddress to_address { get; set; }
        public DateTime postmark_date { get; set; }
        public double total_amount { get; set; }
        public ReportUsps usps { get; set; }
    }


    public class ValidateAddress
    {
        public string company_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
    }


    public class AddressResponse
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string last_line { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string zip5 { get; set; }
        public string zip4 { get; set; }
        public string dpbc { get; set; }
        public string record_type { get; set; }
        public string rdi { get; set; }
        public string dpv { get; set; }
        public string dpv_comment { get; set; }
        public string carrier_route { get; set; }
        public string address_exists { get; set; }
    }

    public class ApiError
    {
        public string code { get; set; }
        public string message { get; set; }
    }


    public class metadata
    {
        public string rubberstamp1 { get; set; }
        public string rubberstamp2 { get; set; }
        public string rubberstamp3 { get; set; }
        public string reference1 { get; set; }
        public string reference2 { get; set; }
        public string reference3 { get; set; }

    }

    public class customs_form
    {
        public string restriction_type { get; set; }
        public string restriction_comments { get; set; }
        public string senders_customs_reference { get; set; }
        public string importers_customs_reference { get; set; }
        public string importers_customs_reference_type { get; set; }
        public string license_number { get; set; }
        public string certificate_number { get; set; }
        public string invoice_number { get; set; }
        public string contents_type { get; set; }
        public string importers_contact { get; set; }
        public string insured_number { get; set; }
        public string pfc_itn { get; set; }
        public customs_item[] customs_items { get; set; }
    }

    public class customs_item
    {
        public string description { get; set; }
        public int quantity { get; set; }
        public double weight { get; set; }
        public string weight_unit { get; set; } // oz, lb, g, kg
        public double value { get; set; }
        public string hs_tariff_number { get; set; }
        public string origin_country_code { get; set; }
    }
    public class Usps
    {
        public string mail_class { get; set; }
        public string entry_facility { get; set; }
        public string ddu_facility_name { get; set; }
        public string shape { get; set; }
        public string image_size { get; set; }
        public List<string> services { get; set; }
        public OpenAndDistribute open_and_distribute { get; set; }
    }
    public class Dimensions
    {
        public decimal height { get; set; }
        public decimal width { get; set; }
        public decimal length { get; set; }

    }


    public class OpenAndDistribute
    {
        public string container { get; set; }
        public string enclosed_mail_class { get; set; }
        public string enclosed_shape { get; set; }

    }
    public class LabelRequest
    {
        public string request_id { get; set; }

        [JsonProperty("from_address")]
        public FromAddress FromAddress { get; set; }
        [JsonProperty("to_address")]
        public ToAddress ToAddress { get; set; }
        public decimal weight { get; set; }
        public string weight_unit { get; set; }
        public string image_format { get; set; }
        public int image_resolution { get; set; }
        public Usps usps { get; set; }
        public Dimensions dimensions { get; set; }
        public String dimensions_unit { get; set; }
        public String postmark_date { get; set; }
        public double value { get; set; }
        public customs_form customs_form { get; set; }
        public metadata metadata { get; set; }
    }

    public class ManifestRequest
    {
        public string image_format { get; set; }
        public int image_resolution { get; set; }
        public Usps usps { get; set; }
        public string request_id { get; set; }
    }

    public class Fee
    {
        public string name { get; set; }
        public double fee { get; set; }
    }

    public class UspsResponse
    {
        public List<string> tracking_numbers { get; set; }
        public string pricing { get; set; }
        public List<Fee> fees { get; set; }
        public int zone { get; set; }
    }

    public class UspsManifestResponse
    {
        public string base64_manifest { get; set; }
        public string manifest_number { get; set; }
        public int priority_count { get; set; }
        public int express_count { get; set; }
        public int pmi_count { get; set; }
        public int emi_count { get; set; }
        public int gxg_count { get; set; }
        public int other_count { get; set; }
    }

    public class LabelResponse
    {
        public string request_id { get; set; }
        public string status { get; set; }
        public DateTime postmark_date { get; set; }
        public double postage_amount { get; set; }
        public double fees_amount { get; set; }
        public double total_amount { get; set; }
        public UspsResponse usps { get; set; }
        public List<string> base64_labels { get; set; }
    }

    public class ManifestResponse
    {
        public UspsManifestResponse[] usps { get; set; }

    }

    public class ePostageLabelApi
    {
        public string url { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public LabelResponse CreateLabel(LabelRequest labelRequest)
        {

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(" https://" + url + "/v1/labels");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(labelRequest,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                File.WriteAllText("json.txt", json); // remove for production
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var json = streamReader.ReadToEnd();
                    LabelResponse response = JsonConvert.DeserializeObject<LabelResponse>(json);
                    return response;
                }
            }

            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;

                    string responseText = String.Empty;
                    String errMessage = String.Empty;
                    using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                        ApiError response = JsonConvert.DeserializeObject<ApiError>(responseText);
                        throw new ApiException((int)resp.StatusCode, response);
                    }

                }
                return null;
            }
        }


        public ManifestResponse CreateManifest(ManifestRequest manifestRequest)
        {

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(" https://" + url + "/v1/manifests");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(manifestRequest,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                File.WriteAllText("json_manifest.txt", json); // remove for production
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var json = streamReader.ReadToEnd();
                    ManifestResponse response = JsonConvert.DeserializeObject<ManifestResponse>(json);
                    return response;
                }
            }

            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;

                    string responseText = String.Empty;
                    String errMessage = String.Empty;
                    using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                        ApiError response = JsonConvert.DeserializeObject<ApiError>(responseText);
                        throw new ApiException((int)resp.StatusCode, response);
                    }

                }
                return null;
            }
        }

        public void VoidLabel(string trackingNumber)
        {
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(" https://" + url + "/v1/labels/" + trackingNumber);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);
            try
            {
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException ex)
            {
                var resp = (HttpWebResponse)ex.Response;
                ApiError myError = new ApiError();
                myError.code = "404";
                myError.message = "Code 404.  Label is not found or already voided.";
                throw new ApiException(404, myError);
            }
        }

        public LabelResponse ReprintLabel(string trackingNumber) { return null; }
    }
}