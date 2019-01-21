(Brief) Explanation of Solution
NB I haven't actually taken a proper course on discrete maths yet, so I
apologise in advance

This algorithm takes advantage of the fact that as the size of the spiral (r)
increases from 1, ie the minimum distance a program will have to travel either
horizontally OR vertically increases, the number of elements in the spiral
increases at a rate of (2r-1)^2.

Conveniently, as the value of each element is the same as their position in the
spiral, which means every increase in size occurs at a value of (2r-1)^2.

For this reason, our algorithm treats the spiral as a set of squares
R_1..R_n. Each square contains all the values from ((2r-3)^2)-1 to
(2r-1)^2.

To find R_r for any given value x, we just have to find the next largest value of
(2r-1)^2 from x. We can do this efficiently by finding the next largest 2r-1
from x^1/2, by flooring x^1/2 and increasing by 1 or 2 if even or odd
respectively.

The full Manhattan distance is equivalent to r-1 + a, where a is the offset
from the position the program arrives at when it has reached R_r. To find
a, we simply calculate a centre for each edge of the square R_r, starting at
(2r-1)^2 - (2r-2)/2 and subtracting (2r-2) until we have a value lower than r.
