import matplotlib.pyplot as plt
import pandas as pd

plt.rcParams["figure.autolayout"] = True
fig = plt.figure()
ax = fig.add_subplot(projection='3d')

path = "D:\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\Data\data.csv"


def Tutu():
    data = pd.read_csv(path, sep=';', encoding = 'cp866')

    xx = data['X']
    yy = data['Y']
    zz = data['Y']
    
    x=[xx[i] for i in range(0,len(xx),200)]
    y=[yy[i] for i in range(0,len(yy),200)]
    z=[i for i in range(0,len(zz),200)]
    ax.scatter(x, z, y)

    ax.set_xlabel('X')
    ax.set_ylabel('Z')
    ax.set_zlabel('Y')
    ax.set_title('3D data.csv')

    plt.show()

Tutu()
