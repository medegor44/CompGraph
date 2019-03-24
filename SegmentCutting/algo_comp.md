﻿Сравнение алгоритмов Коэна-Сазерленда и алгоритма средней точки.
Выполнено на квадрате [0, 10]x[0, 10] с eps = 1e-6.

| Отрезок             | Коэн-Сазерленд | Сердней точки |
|---------------------|------------------|---------------|
| -5 5 5 5            | 3                | 49            |
| -10 15 18 -2        | 5                | 99            |
| -1 0 -1 10          | 1                | 1             |
| -1 1 1 -1           | 3                | 87            |
| -1 1 1,5 -1         | 5                | 87            |
| 1 1 5 5             | 1                | 1             |
| 1 1 10 10           | 1                | 1             |
| 1 1 10,5 10,5       | 3                | 49            |
| -0,5 -0,5 10,5 10,5 | 5                | 95            |
| -1 2 1 -1           | 5                | 87            |