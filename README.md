# qa-automation-assessment

UI Test Automation
Using any UI open-source automation tool of your choice, automate the following:
Application URL: https://www.demo.bnz.co.nz/client/
TC1: Verify you can navigate to Payees page using the navigation menu
1. Click ‘Menu’
2. Click ‘Payees’
3. Verify Payees page is loaded
TC2: Verify you can add new payee in the Payees page
1. Navigate to Payees page
2. Click ‘Add’ button
3. Enter the payee details (name, account number)
4. Click ‘Add’ button
5. ‘Payee added’ message is displayed, and payee is added in the list of payees
TC3: Verify payee name is a required field
1. Navigate to Payees page
2. Click ‘Add’ button
3. Click ‘Add’ button
4. Validate errors
5. Populate mandatory fields
6. Validate errors are gone
TC4: Verify that payees can be sorted by name
1. Navigate to Payees page
2. Add new payee
3. Verify list is sorted in ascending order by default
4. Click Name header
5. Verify list is sorted in descending order
TC5: Navigate to Payments page
1. Navigate to Payments page
2. Transfer $500 from Everyday account to Bills account
3. Transfer successful message is displayed
4. Verify the current balance of Everyday account and Bills account are correct
Note: Run this test 3 times to ensure 100% pass rate
Bonus:
1. Run the tests within a continuous integration pipeline
2. Run the tests in docker
3. Run the tests in different browsers
4. Run the tests in parallel
API Test Automation
Using any API open-source test tool of your choice, automate the following:
Request URL: https://jsonplaceholder.typicode.com/users
TC1: Verify GET Users request
1. Verify 200 OK message is returned
2. Verify that there are 10 users in the results
TC2: Verify GET User request by Id
1. Verify 200 OK message is returned
2. Verify if user with id8 is Nicholas Runolfsdottir V
TC3: Verify POST Users request
1. Verify 201 Created message is returned
2. Verify that the posted data are showing up in the result
Bonus:
1. Parameterised your tests
2. Run the tests within a continuous integration pipeline 
