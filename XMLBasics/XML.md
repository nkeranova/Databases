#XML

##XML (eXtensible Markup Language)
* Universal language (notation) for describing structured data using text with tags
  * The data is stored together with the meta-data about it
  * Used to describe other languages (formats) for data representation
* XML looks like HTML
  * Text based language, uses tags and attributes
  
###Why Study XML?
XML plays an important role in many IT systems.

For this reason, it is important for all software developers to have a good understanding of XML.

Before you continue, you should also have a basic understanding of:

 * HTML
 * JavaScript

If you want to study these subjects first, find the tutorials on our Home page.

###What is XML?
 * XML stands for EXtensible Markup Language
 * XML is a markup language much like HTML
 * XML was designed to store and transport data
 * XML was designed to be self-descriptive
 * XML is a W3C Recommendation

###XML Does Not Use Predefined Tags
 * The XML language has no predefined tags.
 * With XML, the author must define both the tags and the document structure.

###XML is Extensible
 * Most XML applications will work as expected even if new data is added (or removed).
 * Imagine an application designed to display the original version of note.xml (<to> <from> <heading> <data>).
 * Then imagine a newer version of note.xml with added <date> and <hour> elements, and a removed <heading>.

##XML Namespaces

XML Namespaces provide a method to avoid element name conflicts.

###Name Conflicts
In XML, element names are defined by the developer. This often results in a conflict when trying to mix XML documents from different XML applications.

###Solving the Name Conflict Using a Prefix
Name conflicts in XML can easily be avoided using a name prefix.

###XML Namespaces - The xmlns Attribute
 * When using prefixes in XML, a namespace for the prefix must be defined.
 * The namespace can be defined by an xmlns attribute in the start tag of an element.
 * The namespace declaration has the following syntax. xmlns:prefix="URI".
 
###Uniform Resource Identifier (URI)
A Uniform Resource Identifier (URI) is a string of characters which identifies an Internet Resource.

The most common URI is the Uniform Resource Locator (URL) which identifies an Internet domain address. Another, not so common type of URI is the Universal Resource Name (URN).

###Default Namespaces
Defining a default namespace for an element saves us from using prefixes in all the child elements.

##URI
"URI" redirects here. For other uses, see URI (disambiguation).
In information technology, a Uniform Resource Identifier (URI) is a string of characters used to identify a resource. Such identification enables interaction with representations of the resource over a network, typically the World Wide Web, using specific protocols. Schemes specifying a concrete syntax and associated protocols define each URI. The most common form of URI is the Uniform Resource Locator (URL), frequently referred to informally as a web address. More rarely seen in usage is the Uniform Resource Name (URN), which was designed to complement URLs by providing a mechanism for the identification of resources in particular namespaces.

##URLs
Main article: Uniform Resource Locator
A URL is a URI that, in addition to identifying a web resource, specifies the means of acting upon or obtaining the representation of it, i.e. specifying both its primary access mechanism and network location. For example, the URL http://example.org/wiki/Main_Page refers to a resource identified as /wiki/Main_Page whose representation, in the form of HTML and related code, is obtainable via Hypertext Transfer Protocol (http) from a network host whose domain name is example.org.

##URNs
Main article: Uniform Resource Name
A URN is a URI that identifies a resource by name in a particular namespace. A URN may be used to talk about a resource without implying its location or how to access it. For example, in the International Standard Book Number (ISBN) system, ISBN 0-486-27557-4 identifies a specific edition of Shakespeare's play Romeo and Juliet. The URN for that edition would be urn:isbn:0-486-27557-4. To gain access to the book, its location is needed, for which a URL would have to be specified.

###Relationship between URIs, URLs, and URNs
A Uniform Resource Name (URN) can be compared to a person's name, while a Uniform Resource Locator (URL) can be compared to their street address. In other words, a URN identifies an item and a URL provides a method for finding it.




















