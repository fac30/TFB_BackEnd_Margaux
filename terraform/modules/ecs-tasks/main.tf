# Create IAM Role for ECS task
resource "aws_iam_role" "ecs_task_execution_role" {
  name               = "ecs-tasks-execute"
  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action    = "sts:AssumeRole"
        Effect    = "Allow"
        Principal = {
          Service = "ecs-tasks.amazonaws.com"
        }
      }
    ]
  })
}

# Create CloudWatch Logs policy (allows ECS tasks to write logs to CloudWatch)
resource "aws_iam_policy" "ecs_cloudwatch_logs_policy" {
  name        = "ECSCloudWatchLogsPolicy"
  description = "Allows ECS tasks to send logs to CloudWatch"

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

# Attach CloudWatch Logs policy to ECS Task role
resource "aws_iam_role_policy_attachment" "ecs_cloudwatch_logs_attachment" {
  policy_arn = aws_iam_policy.ecs_cloudwatch_logs_policy.arn
  role       = aws_iam_role.ecs_task_execution_role.name
}

# Create ECR permissions policy (to allow ECS tasks to pull images from ECR)
resource "aws_iam_policy" "ecs_ecr_permissions_policy" {
  name        = "ECRPermissionsPolicy"
  description = "Allows ECS tasks to pull images from ECR"

  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action   = [
          "ecr:GetAuthorizationToken",
          "ecr:BatchCheckLayerAvailability",
          "ecr:GetRepositoryPolicy",
          "ecr:BatchGetImage"
        ]
        Effect   = "Allow"
        Resource = "*"
      }
    ]
  })
}

# Attach ECR permissions policy to ECS Task role
resource "aws_iam_role_policy_attachment" "ecs_ecr_permissions_attachment" {
  policy_arn = aws_iam_policy.ecs_ecr_permissions_policy.arn
  role       = aws_iam_role.ecs_task_execution_role.name
}
