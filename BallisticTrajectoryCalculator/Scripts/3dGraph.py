import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from mpl_toolkits.mplot3d import Axes3D
from matplotlib.offsetbox import OffsetImage, AnnotationBbox
from PIL import Image

plt.rcParams["figure.autolayout"] = True
fig = plt.figure()
ax = fig.add_subplot(111,projection='3d')

path = "D:\\BallisticTrajectoryCalculator\\BallisticTrajectoryCalculator\\BallisticTrajectoryCalculator\\Data\\data.csv"

im = plt.imread('123849-OQI1LL-933.jpg')
def main():
    data = pd.read_csv(path, sep=';', encoding='cp866')    
    x=[data["X"][i] for i in range(0,len(data["X"]))]
    y=[data["Y"][i] for i in range(0,len(data['Y']))]
    z=[0 for _ in range(0,len(data['Y']))]
    x_pos, y_pos = 2, 0
    z_pos = np.interp(x_pos, x, y)

    imbox = OffsetImage(im, zoom=0.2)
    imbox.image.axes = ax
    xx, yy = ax.transData.transform((x_pos, y_pos))
    imbox.set_offset((xx, z_pos))

    ax.add_artist(imbox)
    ax.plot(x, z, y)
    
    
    ax.set_xlabel('X')
    ax.set_ylabel('Z')
    ax.set_zlabel('Y')
     
    ax.set_title('3D data.csv')

    plt.show()

if __name__ == '__main__':
    main()
