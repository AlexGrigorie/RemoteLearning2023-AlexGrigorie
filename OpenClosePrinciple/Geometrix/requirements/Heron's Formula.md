# Heron's Formula

Heron's formula, also known as Hero's formula, is the formula to calculate triangle area given three triangle sides. It was first mentioned in Heron's book Metrica, written in ca. 60 AD, which was the collection of formulas for various objects surfaces and volumes calculation. The basic formulation is:

$$
area = \sqrt{s*(s-a)*(s-b)*(s-c)}
$$

where s is the semiperimeter - half of triangle perimeter:

$$
s = \frac{a + b + c}{2}
$$

However, other forms of this formula exist - if you do not want to calculate the semiperimeter by hand, you can use the formula with side lengths only:

$$
area = 0.25 * \sqrt{(a + b + c) * (-a + b + c) * (a - b + c) * (a + b - c)}
$$
