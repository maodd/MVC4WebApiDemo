MVC4WebApiDemo
==============
Some extensions for base MVC4 Web API template

The only file modified is ValuesController.cs, and it should rename to BookController.

List:

1. Changed default string value parameter to Book model
2. POST/PUT/Delete return HttpResponseMessage instead of void.
3. Full implementation of POST. (no db interaction) 
4. Return validation error messages in POST.