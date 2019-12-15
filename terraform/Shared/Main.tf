provider "aws" {
  alias = "us-east-1"

  region = "us-east-1"
  profile = "jeff-terraform-user"
}

# store remote terraform state in S3
terraform {
  backend "s3" {
    profile = "jeff-terraform-user"
  }
}

resource "aws_ecr_repository" "docit_service_ecr" {
  provider = "aws.us-east-1"

  name = "docit_ecr"
  
  lifecycle {
    prevent_destroy = true
  }
}