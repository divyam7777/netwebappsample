<h1 align="center">
  NetWebAppSample
</h1>

<h4 align="center">A lightweight .NET web application sample for exploratory testing of .NET platforms</h4>

<h4 align="center">
  <a href="#features">Features</a>&nbsp;|&nbsp;
  <a href="#download">Download</a>&nbsp;|&nbsp;
  <a href="#download">Installation</a>&nbsp;|&nbsp;
  <a href="#credits">License</a>&nbsp;|&nbsp;
  <a href="#credits">Credits</a>
</h4>

![Query tab screenshot](https://raw.githubusercontent.com/mayakron/netwebappsample/main/resources/NetWebAppSampleHomepageScreenshot.png)

## Features

NetWebAppSample is a lightweight .NET web application sample for exploratory testing of .NET platforms.

It is designed as an application that "just works" with as little dependencies as possible. It can be useful to verify that an environment (e.g. a public or private cloud .NET hosting solution, a Docker container in a Kubernetes cluster, standalone Windows or Linux servers, etc.) is correctly configured to serve .NET web applications.

## Download

The latest and all other versions of NetWebAppSample can be downloaded from [here](https://github.com/mayakron/netwebappsample/releases).

## Installation

As usual for .NET Core and .NET 5/6 web apps, NetWebAppSample can be served on Windows using Kestrel, IIS or HTTP.sys and on Linux using Kestrel (whether proxied by Apache, nginx, or standalone).

Additionally, there are Docker images available:

* docker pull mayakron/netwebappsample-net5.0.12-alpine3.14
* docker pull mayakron/netwebappsample-netcore3.1.21-alpine3.14

## License

[GPLv3](https://www.gnu.org/licenses/gpl-3.0.en.html)

## Credits

This software uses the following open source packages:

- [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.2)