import math
import matplotlib.pyplot as plt

log = []
linear = []
nlogn = []
quadratic = []

for n in range(1, 21):
    linear.append(n)
    log.append(math.log(n))
    nlogn.append(n * math.log(n))
    quadratic.append(n * n)

plt.plot(linear, label="N")
plt.plot(log, label="log N")
plt.plot(nlogn, label="N log N")
plt.plot(quadratic[0:10], label="N * N")
plt.legend()
plt.show()

