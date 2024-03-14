# Pensopay Payments

[![Build Status](https://app.travis-ci.com/V4LVE/Pensopay.svg?token=Lqb5C91ckQA2q6UpBZyQ&branch=master)](https://app.travis-ci.com/V4LVE/Pensopay)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![Package](https://img.shields.io/badge/Package-Nuget-red)](https://opensource.org/licenses/MIT)

Pensopay Payments is the unoffical .net nuget package for the [Pensopay API](https://docs.pensopay.com/v2.0/reference/getting-started). It is a wrapper for the Pensopay API, and makes it easy to integrate Pensopay into your .net project.

## Installation

You can either download our source directly from the GitHub repo, or install the nuget package which can be found on [nuget .org](https://www.google.dk/).

## Usage

Before you can use this package, you need to have a Pensopay account. You can create one [here](https://app.pensopay.com/).
You also need a payment agreement, which you can create right [here](https://dashboard.pensopay.com/register?partner=colmornconsulting)

### Services

The communication with Pensopay is done through the servies classes. They each represent a part of the Pensopay API.
Currently there is support for the following services:

- [x] PaymentService
- [x] AccountService
- [x] SubscriptionServce (Not yet implemented, but is planned)


Each service has a set of methods, which corresponds to the endpoints in the Pensopay API. The methods are async, and returns a response object, which contains the response from the Pensopay API.
Each service must be initialised with a valid baerer token, which can be obtained from the Pensopay dashboard.

### Models

The requests and responses that are supported by the services also comes with model classes, so parsing of the http response is done for you.

### Extension
Extension
If you need access to other endpoints than what is available in the current version, please feel free to suggest them under [issues](https://github.com/V4LVE/Pensopay/issues).

You can also take matters into your own hand and implement the missing parts yourself.
To do this you can create your own service class and let it extend the PensoPayRestClient, which will ensure that the correct header values are added to the requests.

## Examples
 Under construction.

## Isues
if you find any issues, please report them in the [issues](https://github.com/V4LVE/Pensopay/issues) section of the repo.
It will then get sorted as soon as possible.




## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Disclaimer
This package is not affiliated with Pensopay in any way. It is an unoffical package, and is not supported by Pensopay.

## License

[MIT](https://choosealicense.com/licenses/mit/)