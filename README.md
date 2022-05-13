
# Expense Tracker

Expense Tracker application can record daily expenditure in different categories.

# How to Run application after clone the project from Github.

# 1st Step : Migration Using Package manager console
1. **Add migration using below code :**
```bash
add-migration
```
1. **Update database using below code :**
```bash
update-database
```
## Total Pages : 
1. **Expense Tracker**
3. **Category Setup**


### How to operate application

1. After run the application Home page **Expense Trcker** will be shown to the user .
### Add Category : 
2. Before create Expense record **First create Expense Categories** and user can go to **Expense Category** page from top navigation menu.
3. Click on Create Button for Add new category. After create a new category user navigate to the Expense category Index page.
### Edit Category :
4. Edit action is shown at right of the record . By clicking on Edit action user navigate to the Edit page.
5. After Edit Category user Click on Save button for Save the Record and navigate to the index page.
### Delete Category :
4. Delete action is shown at right of the record . By clicking on Delete action user navigate to the Delete page.
5. user can delete the record by click on the Delete Button and navigate to the index page.

**User can add multiple category using above operation:** 

## Add Expense Record
1. Create a new expense record click on **Create New** action at the right of the page.
2. After click **Create New** action user navigate to the Create page.

* User can select **Expense Category** from dropdownlist
* Input **Expense date** from calender.
* Input **Amount** must be integer and decimal. 

3. After all input Click on **Save** button for save the record and navigate to the index page.

## Edit Expense Record
4. **Edit** button place on the right of the record. click on edit button and navigate to the Create page again for edit the record.
* User can edit **Expense Category** by select **Expense Category** from dropdownlist
* edit **Expense date** from calender.
* edit **Amount** must be integer and decimal. 
5. After all edit input Click on **Save** button for save the record and navigate to the index page.

## Delete Expense Record
6. **Delete** button place on the right of the record. click on Delete button and a confirmation massage will be shown to the user for delete. after click yes record will be deleted from the list.

## Date wise Expense Record shown
1. Select **From date** and **To date** on the top of the list. 
2. click on **Submit** button for get data. And date wise data will be shown to the list.
3. Right of the **Submit** button **Get All** action is placed after click on **Get all** action user can get all the Expense Record.
