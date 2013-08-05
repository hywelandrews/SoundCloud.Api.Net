# SoundCloud .Net API Wrapper

## Introduction

A wrapper for the SoundCloud API written in .Net with support for authentication using [OAuth 2.0](http://oauth.net/2/).

## Requirements

* .Net >= 4.0
* Visual Studio > 2010

## Examples

The wrapper includes convenient methods used to perform requests on behalf of an authenticated user, or an unauthenticated client. Below you'll find a few quick examples.

Ofcourse you need to handle the authentication first before being able to request and modify protect resources as demonstrated below. Therefor I refer to the [demo application](https://github.com/mptre/ci-soundcloud) which got some example code on how to handle authentication.

### GET

``` C#
protected ISoundCloudApiUnAuthenticated SoundCloudApiUnAuthenticated;

SoundCloudApiUnAuthenticated = SoundCloudApi.CreateClient(ClientId, ClientSecret);
var user = SoundCloudApiUnAuthenticated.User(509497).Get();
```

### POST

``` C#

Currently unsupported

```

### PUT

``` C#

Currently unsupported

```

### DELETE

``` 
```

### Upload track

``` 
```

### Download track

``` 

```

### Update playlist

Many found it difficult to update a existing playlist. Therefor a custom method is available to simplify this matter.

``` 
```

## Feedback and questions

Found a bug or missing a feature? Please create a new issue here on GitHub.

Also make sure to check out the official [documentation](https://github.com/SoundCloud.Api.Net/wiki).

## License

Copyright (c) 2011 Hywel Andrews

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
