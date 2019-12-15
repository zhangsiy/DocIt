# store remote terraform state in S3
terraform {
  backend "s3" {
    profile = "jeff-terraform-user"
  }
}