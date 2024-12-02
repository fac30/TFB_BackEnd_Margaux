resource "aws_iam_role" "ec2_instance_role" {
  name = "ec2_instance-role"
assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action    = "sts:AssumeRole"
        Effect    = "Allow"
        Principal = {
          Service = "ec2.amazonaws.com"
        }
      }
    ]
  })
}

resource "aws_iam_policy" "logs" {
  name = "CloudWatch Logs policy"
  description = "Allows EC2 to send logs to CloudWatch"

 policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action   = ["logs:CreateLogGroup", "logs:CreateLogStream", "logs:PutLogEvents"]
        Effect   = "Allow"
        Resource = "*"  
      }
    ]
  })
}

resource "aws_iam_role_policy_attachment" "CloudWatch_logs_attachment" {
  policy_arn = aws_iam_policy.logs.arn
  role = aws_iam_role.ec2_instance_role.name
}
