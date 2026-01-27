# 📝User Stories

## Why User Stories 🤔

(as opposed to requirements)

**Requirements are the hardest thing to get a customer to define correctly….**

👤Typical customer: I need a database to keep track of my recipes

👩‍💻Developer: Sure, not a problem… here is your database

👤Typical customer: But where is the web page? 

👩‍💻Developer: ? … you didn’t ask or tell me anything about that.

👤Customer: You are a bad company, and I am not paying you.

The point of a user story is to force the customer to tell you what they *need*, not what they think they want.

* User stories are written **throughout** the entire agile project.
  * Everyone in the team participates with the goal of creating the **product backlog** which fully describes the functionality required.
* A Story is incomplete until a discussion about that story has taken place.
* Must be precise in use of language. 



## 🧬Structure

A user story looks like...

As a `__________________________`

I want to `__________________________`

So that I can `__________________________`

* Describes features in the product backlog from a *user’s* perspective.
* User stories are written in the following format:
   As a <role> I want a <feature> so that I can <accomplish something>



## ✅Qualities Each Story Should Have

INVEST is the acronym used for qualities you want in your user stories:

**I – Independent** ⛓️‍💥
 should not need other stories to implement it (where possible).

**N – Negotiable** 💬
 product owner and development team discuss and expand details.

**V – Valuable** 💎
 shows product value to the customer (not technical steps required).

**E – Estimable** 📊
 refined enough that developers can estimate the effort required.

**S – Small** ✂️
 small in executable size (so you can have 6-10 user stores per sprint).

**T – Testable** 🧪
 needs to be testable so development team knows when it is done.



### ❌Bad Example of User Story

The point of a user story is to force the customer to tell you what they *need*, not what they think they want.

**Original Story**

> As a cook
>
> I want to to have a database with my recipes
>
> So that I can publish them to the web

do you see how this story doesn’t hold up?

* “Database” is a **technical solution**, not a user need.
* It jumps to *how* instead of *why*.
* What the user really wants is **publishing recipes**, not owning a database.



### 👍Better User Story

Product Owner (Scrum Member who is in charge of making proper stories). Their role is to help translate what the customer *says* into what they *mean*.

Product Owner: Please customer, from what you said, I can see that you want to publish recipes on the web… perhaps we can restart your stories

**Rewritten Story:**

>  As a cook 
>
>  I want to have access to all of my recipes 
>
>  so that I can pick one and publish it to the web

Why is it better?

* Focuses on the **user need**
* Avoids technical implementation details

*More stories will need to be written to satisfy the customer’s needs (e.g., editing recipes, permissions, formatting, publishing destinations)*



## ✍🏻Adding Details to a Story

We add detail to user stories in two ways:

1️⃣ By splitting a user story into multiple smaller user stories.

2️⃣ By adding “conditions of satisfaction”.



### 1️⃣ Splitting a user story into multiple smaller user stories.

Some user stories are too large (epic) and need to be split into multiple smaller user stories before it can be worked on.

***Example 1***

**EPIC** 

>  As a user I can backup my hard drive.

**Smaller stories**

> As a power user
>
> I can specify files or folders to backup based on size, date created or date modified
>
> so that I have control over what is backed up.

>  As a user 
>
>  I can indicate folders not to backup 
>
>  so that my backup drive isn't filled with things I don't need saved.



The above examples shows how a broad feature like “backup” starts as an epic and is refined into smaller, more specific user stories that address different user needs and levels of expertise.



***Example 2*** 

Entrée comes with a choice of soup or salad and bread

The user can enter a name.  It can be up to 127 characters long



### 2️⃣ Adding “conditions of satisfaction” or acceptance criteria

All user stories must have *acceptance criteria*, which describes the conditions that will describe if the story has been properly implemented.

> As a cook 
>
> I want to have access to all of my recipes 
>
> so that I can pick one and publish it to the web
>
> Acceptance Criteria
>
> * Customer must first select the recipe in the application, 
>
> * When customer clicks ‘upload’, the recipe will then be uploaded to the web



NOTE: where on the web is defined in a different user story.



# 💡ATM Stories Examples

Examples from http://groups.umd.umich.edu/cis/course.des/cis375/active/class5/User-Stories-ATM.pdf



> As a Customer 
>
> I want to Login to my account using a card and a PIN code 
>
> So that I can perform the transactions. 
>
> Acceptance Criteria
>
> * System must validate the card and pin code 
> * In case Customer enters wrong Pin code three times then the system locks the card. 



> As a Customer
>
> I want to to check the balance of my bank account 
>
> So that I can perform transactions. 
>
> Acceptance Criteria
>
> * Customer needs to be logged in before checking balance. 
> * Balance is displayed.



# 🧩🧩Lab 

As a class, read and discuss the user stories in the following document.

http://groups.umd.umich.edu/cis/course.des/cis375/active/class5/User-Stories-ATM.pdf

As a class, write user stories for

‘Bank Manager’ 

‘Security Officer’
