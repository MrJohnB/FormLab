# Coding Challenge

## Introduction

The goal of this exercise is to create a system for generating a dynamic web form.

As an admin user, I want to be able to add, update, and delete fields from this form as well as review any client submitted data.

As a client, I want to be able to see the form, fill it in, and submit my data.

## Instructions

### Backend

Create a C#/.Net 5.0 API capable of the following functionality:

* Admin User
    * Add a new form field definition
        * Fields should include name and field type (string, int, bool, date) properties at a minimum
    * Edit a field definition
    * Delete a field definition
    * Fetch the collection of the field definitions
    * Fetch a list of all form submissions and associated data
* Client User
    * Render the dynamic form
    * Submit and persist the form data

### Frontend

Using react, please create the following:
* A page for the form administrator to manage the field definitions for the forms
* A page for the form administrator to review all form submissions
* A page for the client to view and submit the form

## Submitting your code

Create a private github repository and invite the following as collaborators:
* phil.edminster@treasury4.com
* treasury4-scott

## Questions

If you have any questions, please reach out to Phil (phil.edminster@treasury4.com) or Scott (scott.mccabe@treasury4.com). They will reply as soon as they are able during standard business hours. 
