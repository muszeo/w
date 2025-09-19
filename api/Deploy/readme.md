<b>MyTrucking Metrics API Services</b>

<u>Build & Run</u>

<I>Prerequisites to Build & Run Locally</I>

* Docker
* dotnet 6.0

<I>Build & Run</I>

<code>
$ cd ./local/docker<br>
</code>

To build and run all components, i.e. both the DB and the Web API:

<code>
$ ./provision-local.sh
</code>

* The <code>provision-local.sh</code> script will ditch everything and rebuild it all from scratch.
* Run this command if you are building the server for the <I>first time</I>, and any occasion you want a completely new instance to be created.
* NB. This command will ditch the DB and thus will destroy any users you have setup.

To build and run only the Web App:

<code>
$ ./publish-web.sh<br>
$ ./build-docker-web.sh<br>
$ ./run-docker-web.sh<br>
</code>

* You can use this method to rebuild the Metrics API without impacting the DB.

To build and run only the DB:

<code>
$ ./build-docker-db.sh<br>
$ ./run-docker-db.sh<br>
</code>

<u>Deployment</u>

To run on target deployment host with Docker:

<code>
$ docker stop metric-api-web
$ docker rm -v metric-api-web
$ aws ecr get-login-password --region ap-southeast-2 | docker login --username AWS --password-stdin 439722369110.dkr.ecr.ap-southeast-2.amazonaws.com
$ docker run -d -p 39803:80 --name metric-api-web -e ASPNETCORE_ENVIRONMENT=<environment> -e ASPNETCORE_URLS=http://*:80 439722369110.dkr.ecr.ap-southeast-2.amazonaws.com/metric-api-web:<version>
</code>

To run on target deployment host with AWS CloudWatch Logging, use the following run command instead:

<code>
$ docker run -d -p 39803:80 --name metric-api-web --log-driver=awslogs --log-opt awslogs-region=ap-southeast-2 --log-opt awslogs-group=<targetloggroup> --log-opt awslogs-stream=<targetlogstream> --log-opt awslogs-create-group=true --log-opt mode=non-blocking --log-opt max-buffer-size=4m -e ASPNETCORE_ENVIRONMENT=<environment> -e ASPNETCORE_URLS=http://*:80 439722369110.dkr.ecr.ap-southeast-2.amazonaws.com/metric-api-web:<version>
</code>

For instance, to run in:

SIT:

<code>
$ docker run -d -p 39803:80 --name metric-api-web --log-driver=awslogs --log-opt awslogs-region=ap-southeast-2 --log-opt awslogs-group=sitmetricapilogs --log-opt awslogs-stream=sitmetricapilogs --log-opt awslogs-create-group=true --log-opt mode=non-blocking --log-opt max-buffer-size=4m -e ASPNETCORE_ENVIRONMENT=Sit -e ASPNETCORE_URLS=http://*:80 439722369110.dkr.ecr.ap-southeast-2.amazonaws.com/metric-api-web:0.0.143
</code>

Preproduction:

<code>
$ docker run -d -p 39803:80 --name metric-api-web --log-driver=awslogs --log-opt awslogs-region=ap-southeast-2 --log-opt awslogs-group=preprodmetricapilogs --log-opt awslogs-stream=preprodmetricapilogs --log-opt awslogs-create-group=true --log-opt mode=non-blocking --log-opt max-buffer-size=4m -e ASPNETCORE_ENVIRONMENT=Preprod -e ASPNETCORE_URLS=http://*:80 439722369110.dkr.ecr.ap-southeast-2.amazonaws.com/metric-api-web:0.0.443
</code>

Production:

<code>
$ docker run -d -p 39803:80 --name metric-api-web --log-driver=awslogs --log-opt awslogs-region=ap-southeast-2 --log-opt awslogs-group=prodmetricapilogs --log-opt awslogs-stream=prodmetricapilogs --log-opt awslogs-create-group=true --log-opt mode=non-blocking --log-opt max-buffer-size=4m -e ASPNETCORE_ENVIRONMENT=Prod -e ASPNETCORE_URLS=http://*:80 439722369110.dkr.ecr.ap-southeast-2.amazonaws.com/metric-api-web:0.0.143
</code>

<b>Important Note:</b> To use AWS CloudWatch logs, the Docker host server MUST:

1. Have AWS credentials provided in docker configuration.
2. The credentials must be for a IAM user with appropriate permissions to access CloudWatch and create and modify logs.

To address #1 above:

1. SSH to the target EC2 based Docker host machine.
2. Execute:

<code>
$ sudo mkdir -p /etc/systemd/system/docker.service.d/
$ sudo touch /etc/systemd/system/docker.service.d/aws-credentials.conf
$ sudo nano /etc/systemd/system/docker.service.d/aws-credentials.conf
</code>

3. Add the following lines to the file created in step #2:

<code>
[Service]
Environment="AWS_ACCESS_KEY_ID=<awsuserid>"
Environment="AWS_SECRET_ACCESS_KEY=<awssecretkey>"
</code>

4. Execute:

<code>
$ sudo systemctl daemon-reload
$ sudo service docker restart
</code>

To address #2 above:

1. The IAM user must have the following inline policy attached:

<code>
{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Action": [
                "logs:CreateLogGroup",
                "logs:CreateLogStream",
                "logs:PutLogEvents"
            ],
            "Effect": "Allow",
            "Resource": "*"
        }
    ]
}
</code>

<I>Reverse Proxy Configuration</I>

The following code block should be added to Nginx configuration:

<code>
server {
    listen	80;
    server_name	[DOMAIN NAME OF API];

    proxy_busy_buffers_size	512k;
    proxy_buffers	4	    512k;
    proxy_buffer_size		256k;

    error_page 500 501 502 503 /error-page.html;

    location / {
        proxy_pass http://[IP ADDRESS OF CONTAINER HOST]:39803/;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }

    location = /error-page.html {
            root /var/www/html;
            internal;
    }
}
</code>

For example:

<code>
server {
    listen	80;
    server_name	siteventsapi.mytrucking.nz;

    proxy_busy_buffers_size	512k;
    proxy_buffers	4	    512k;
    proxy_buffer_size		256k;

    error_page 500 501 502 503 /error-page.html;

    location / {
        proxy_pass http://172.45.20.30:39803/;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }

    location = /error-page.html {
            root /var/www/html;
            internal;
    }
}
</code>

<u>Sample AWS Event Bridge Events</u>

The following are example Event definitions for AWS Event Bridge.

<b>Business Event</b>

Event Samples:
<code>
{
  "id": "0",
  "detail-type": "BusinessEvent",
  "source": "com.gomytrucking.api",
  "account": "439722369110",
  "time": "2022-10-21T01:22:33Z",
  "region": "ap-southeast-2",
  "detail": {
    "type": "JobCreatedEvent",
    "company": "1",
    "worker": "1",
    "role": "2",
    "data": {
        "id": 1
    }
  }
}

{
  "id": "0",
  "detail-type": "BusinessEvent",
  "source": "com.gomytrucking.api",
  "account": "439722369110",
  "time": "2022-10-21T01:22:33Z",
  "region": "ap-southeast-2",
  "detail": {
    "type": "SubjectCreatedEvent",
    "company": "1",
    "worker": "1",
    "role": "1",
    "data": {
        "subject": "muszeo",
        "provider": "local",
        "email": "muszeo@icloud.com",
        "identifier": "blar",
        "timestamp": "0"
    }
  }
}
</code>

Event Pattern(s):
<code>
{
  "detail-type": ["BusinessEvent"],
  "detail": {
    "type": ["SubjectCreatedEvent"]
  }
}
</code>

<b>Notification Event</b>

Event Sample(s) Examples:
<code>
{
  "id": "0",
  "detail-type": "NotificationEvent",
  "source": "com.gomytrucking.messaging",
  "account": "439722369110",
  "time": "2022-10-21T01:22:33Z",
  "region": "ap-southeast-2",
  "detail": {
    "network": "MobilePush",
    "address": "arn://....",
    "body": "Hello World",
    "criticality": "information"
  }
}

{
  "id": "0",
  "detail-type": "NotificationEvent",
  "source": "com.gomytrucking.events",
  "account": "439722369110",
  "time": "2022-10-21T01:22:33Z",
  "region": "ap-southeast-2",
  "detail": {
    "network": "email",
    "address": "martin@mytrucking.com",
    "body": "Hello World",
    "criticality": "normal"
  }
}
</code>

Event Pattern(s) Examples:
<code>
{
  "account": ["439722369110"],
  "detail-type": ["NotificationEvent"],
  "source": ["com.gomytrucking.messaging"],
  "detail": {
    "network": ["MobilePush"]
  }
}

{
  "detail-type": ["NotificationEvent"],
  "detail.network": ["email"]
}

{
  "detail-type": ["NotificationEvent"],
  "detail": {
    "network": ["email"]
  }
}
</code>

<b>Intercom Events</b>

Event Pattern(s):
<code>
{
  "detail-type": ["BusinessEvent"],
  "detail": {
    "type": ["SubjectCreatedEvent"]
  }
}
</code>

Intercom Event (Output) Sample(s):
<code>
{
  "event_name" : "SubjectCreatedEvent",
  "created_at": 1389913941,
  "user_id": "16789",
  "metadata": {
    "data": {
        "subject": "muszeo",
        "provider": "local",
        "email": "muszeo@icloud.com",
        "identifier": "blar",
        "timestamp": "0"
    }
  }
}
</code>