resource "aws_instance" "tfb" {
  ami           = var.ami
  instance_type = var.instance_type

  security_groups = [aws_security_group.tfb_sec.name]
  key_name        = "Margeaux"

  tags = {
    Name = "TFB_Backend"
  }
}

resource "aws_security_group" "tfb_sec" {
  name        = "tfb_security"
  description = "we need security measures"

  ingress {
    from_port   = 22
    to_port     = 22
    protocol    = "tcp"
    cidr_blocks = ["212.69.43.233/32"]
  }
  ingress {
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = -1
    cidr_blocks = ["0.0.0.0/0"]
  }

  tags = {
    Name = "TFB_Security"
  }
}
