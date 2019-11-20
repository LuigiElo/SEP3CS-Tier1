﻿﻿namespace SEP3.Models
{
    public class Response
    {
        public bool status { get; set; }
        public string message { get; set; }
        
        
        public bool isStatus() {
            return status;
        }

        public void setStatus(bool status) {
            this.status = status;
        }

        public string getMessage() {
            return message;
        }

        public void setMessage(string message) {
            this.message = message;
        }
    }
}