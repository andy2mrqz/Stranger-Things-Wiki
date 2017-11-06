## Stranger Things Project Page
### Parts 1 & 2 combined and condensed

#### Overview

Create an MVC website and database that will allow Stranger Things enthusiasts to ask questions of other fans.  The site must also implement 3rd party authentication, through Google for example.

On the landing page, implement a bootstrap jumbotron class to create a “call to action” which for now will not have any functionality.
The home page, should also display any content that relates to Stranger Things (i.e. quotes, videos, etc.)

#### Views

On the landing page there will be three main links:
1. Characters – should take you to the characters view
    - The characters view will have a dropdown that will consist of several characters
    - As the user clicks on an entry in the list, take them to another view (_so-and-so_ character FAQ’s) which is dynamically loaded using source code.
    - For now, the questions and answers on the view for each character will all be the same (HARD CODED - You will create the question and answer), regardless of which character is chosen. You must however pass the following unique information for each character in the viewbag:
      - character first and last name
      - character description
      - year of birth
      - gender
      - hometown
      - occupation
      - actor
      - famous quote
      - profile image
    - Display this information in a section above the FAQ's
    - Beneath the character profile image and information, display the FAQs list.  Under each question, there will need to be a way for a user to answer that question.  Use a reply button to have a response form dynamically created when a fan wants to answer another fan's question.  You do not need to save replies for this project.
    - At the very bottom of each character's FAQ's page will be a question form.  The user will be able to fill out this form to post a new question, just like a comment on Facebook.

2. About us- should take you to the About view
    - The About view should display “made up” information about the company that wants to help Stranger Things fans get questions about characters answered by those that have seen the show.
 
3. Contact – should take you to the Contact view
    - The contact view will have basic company information, such as phone number and email.
    - The view will also have a contact form that will have fields for the user’s name, email, subject(choose from a list), and message body.
    - There will need to be a submit button at the bottom of the contact form. This button however, won’t do anything with the data yet. For now it will just clear the text in the form.
    
** **Implement a bootstrap breadcrumb at the top of each view to facilitate navigation.  Using the breadcrumb, the user should be able to go back to the characters page to select a different character** **

#### Database

* For the database, three tables are required: Characters, Users, and CharacterQuestions.

#### Log In
* Create a login page which allows a user to login with an email address and password.
* This view will also have a link that will allow them to create a new account/user. Once that account is created they are automatically logged in.
  * You will not have to worry about maintaining the account once it is created. You will use a lookup(find) to the User table to authenticate the user.
* Add authentication rules to implement the following logic:
  * The user must be logged in to view the FAQ page.
  * If an unauthorized user tries to access the FAQ page redirect them to the Login page.
  * Users that are not authenticated can still see the character view, they just can't get to the FAQ view to review questions and add questions
  
* Once in the FAQ page, add functionality so the user can post a question or reply to a question.
  * These should be saved to the MissionQuestions table. Once the question is posted, the question cannot be deleted or edited.
  * However, the answer can be changed over and over again (similar to a wiki) by any authorized user.
  * You will store the latest answer inputted (there is only 1 answer per question).

#### Finally...
Schedule a time to meet with TAs for grading
