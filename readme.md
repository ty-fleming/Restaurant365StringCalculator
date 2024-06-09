# Restaurant365 Code Challenge - String Calculator

## Summary

Create a calculator that only supports an Add operation given a single formatted string.

- Provide code via a public distributed version control repository i.e. GitHub. Do NOT fork this repo
- Console application using the language defined by your interviewer
- Include unit tests
- Show each requirement step as a separate commit. Think of each step as a "requirement change"
- Efficient code is always important but for this exercise... readability and separation of concerns are much more critical
- Excluding stretch goals will not affect your overall assessment but implementing them poorly will

## Requirements

- [x] Support a maximum of 2 numbers using a comma delimiter. Throw an exception when more than 2 numbers are provided
- [x] Remove the maximum constraint for numbers e.g. 1,2,3,4,5,6,7,8,9,10,11,12 will return 78
- [x] Support a newline character as an alternative delimiter e.g. 1\n2,3 will return 6
- [x] Deny negative numbers by throwing an exception that includes all of the negative numbers provided
- [x] Make any value greater than 1000 an invalid number e.g. 2,1001,6 will return 8
- [x] Support 1 custom delimiter of a single character using the format: //{delimiter}\n{numbers}
    - [x] all previous formats should also be supported
- [x] Support 1 custom delimiter of any length using the format: //[{delimiter}]\n{numbers}
    - [x] all previous formats should also be supported
- [x] Support multiple delimiters of any length using the format: //[{delimiter1}][{delimiter2}]...\n{numbers}
    - [x] all previous formats should also be supported

## Stretch Goals

- [ ] Display the formula used to calculate the result e.g. 2,,4,rrrr,1001,6 will return 2+0+4+0+0+6 = 12
- [x] Allow the application to process entered entries until Ctrl+C is used
- [ ] Allow the acceptance of arguments to define...
    - [ ] alternate delimiter in step #3
    - [ ] toggle whether to deny negative numbers in step #4
    - [ ] upper bound in step #5
- [ ] Use DI
- [ ] Support subtraction, multiplication, and division operations

