### Hallpass and Friends
# Advent of Code - 2023

## Notes

### Day #1
In part *A*, I interate through a line looking for digits replacing `last` with any that I find so that at the end, `last` represents the last digit found.  (note: `first` is set once a digit is found.)
```
foreach char in line
	if (char is a digit)
		if (first is null) first = digit
		last = digit
	end
end
```

In part *B*, I tried this same approach, checking for spelled out digits if the char is not a digit.
```
for index=0; index < line length; index++
	current = line from index
	if (current[0] is a digit)
		if (first is null) first = digit
		last = digit
	else if current starts with spelled_out_digit
		if (first is null) first = value of spelled_out_digit
		last = value of spelled_out_digit
	end
end
```
This works, but I realized that it is less effient than traversing the line backwards to find the `last` value.  My resulting approach traverses the line forward to get `first`, quitting once found, and backwards to get `last`, again quitting once found. 

I include both approaches in the code.
