# String Calculator

- Create a simple String calculator with a method int Add(string numbers)
  * The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example "" or "1" or "1,2"
  * Start with the simplest test case of an empty string, then move to one and two numbers
- Allow the Add method to handle an unknown amount of numbers
- Allow the Add method to handle new lines between numbers (in addition to commas).
  * the following input is ok: "1\n2,3" (will equal 6)
  * the following input DOES NOT need to be handled: "1,\n" (not need to prove it - just clarifying)
- Support different delimiters
  * To change a delimiter, the beginning of the string will contain a separate line specifying the
    custom delimiter. This input looks like this: "//{delimiter}\n{numbers...}" (Note that the curly
    braces are representing the sections of the input and are not input formatting).
  * For example: "//;\n1;2" should return a result of 3 because the delimiter is now ‘;’.
  * The first line is optional (all existing scenarios should still be supported).
  * Do not worry about supporting the specification of ‘\n’ as an explicit custom delimiter. New lines
    should always be supported as delimiters in your number string.
- Calling Add with a negative number will throw an exception "negatives not allowed" - and the negative
  that was passed, if there are multiple negatives, show all of them in the exception message
- Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2

# Bonus

- Delimiters can be of any length with the following format: "//[{delimiter}]\n{numbers...}"
  * For example: "//[***]\n1***2***3" should return 6.
  * Note that the square brackets are required around the multiple character delimiter.
  * A square bracket is not a valid delimiter.
- Allow multiple delimiters like this: "//[{delim1}][{delim2}]\n{numbers...}"
  * For example "//[*][%]\n1*2%3" should return 6.
  * Note that once again the square brackets are required around each custom delimiter.
- Make sure you can also handle multiple delimiters with length longer than one char
