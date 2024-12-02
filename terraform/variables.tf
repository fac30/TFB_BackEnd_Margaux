variable "region" {
  default     = "eu-west-2"
  description = "region of which your resources live and operate"
}

variable "ami" {
  default     = "ami-0acc77abdfc7ed5a6"
  description = "OS and server configuration for the backend logic"
}

variable "instance_type" {
  default     = "t2.micro"
  description = "storage and computer power"
}




