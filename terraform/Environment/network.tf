# Fetch AZs in the current region
data "aws_availability_zones" "available" {
    provider = "aws.us-east-1"
}

# TODO: Reuse one VPC for multiple services in domain (will need to figure out how to coordinate cidr blocks)
resource "aws_vpc" "vpc" {
  provider = "aws.us-east-1"
  
  cidr_block = "10.0.0.0/16"

  tags {
    Name = "ECS ${var.environment}-${var.app_name}-cluster - VPC"
    Environment = "${var.environment}"
    Domain = "${var.domain_name}"
    App = "${var.app_name}"
  }
}

resource "aws_subnet" "public_subnets" {
  provider = "aws.us-east-1"
  
  count                   = "${var.az_count}"
  cidr_block              = "10.0.${count.index}.0/24"
  availability_zone       = "${data.aws_availability_zones.available.names[count.index]}"
  vpc_id                  = "${aws_vpc.vpc.id}"
  map_public_ip_on_launch = true

  tags {
    Name = "ECS ${var.environment}-${var.app_name}-cluster - Public Subnet ${count.index + 1}"
    Environment = "${var.environment}"
    Domain = "${var.domain_name}"
    App = "${var.app_name}"
  }
}

resource "aws_internet_gateway" "igw" {
  provider = "aws.us-east-1"
  
  vpc_id = "${aws_vpc.vpc.id}"

  tags {
    Name = "ECS ${var.environment}-${var.app_name}-cluster - InternetGateway"
    Environment = "${var.environment}"
    Domain = "${var.domain_name}"
    App = "${var.app_name}"
  }
}

resource "aws_route" "route" {
  provider = "aws.us-east-1"
  
  route_table_id = "${aws_vpc.vpc.main_route_table_id}"
  destination_cidr_block = "0.0.0.0/0"
  gateway_id = "${aws_internet_gateway.igw.id}"
}