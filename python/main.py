import os
import pandas as pd
import random

script_directory = os.path.dirname(os.path.abspath(__file__))

cars_file_name = 'cars.csv'

cars_file_path = os.path.join(script_directory, cars_file_name)

if os.path.exists(cars_file_path):
    car_df = pd.read_csv(cars_file_path)

    regos = car_df['rego'].tolist()

else:
    print(f"The file '{cars_file_path}' does not exist.")


people_file_name = 'people.csv'

people_file_path = os.path.join(script_directory, people_file_name)

if os.path.exists(people_file_path):
    people_df = pd.read_csv(people_file_path)

    people_df['rego'] = random.choices(regos, k=len(people_df))

    people_df.to_csv('people_rego.csv', index=False)

else:
    print(f"The file '{people_file_path}' does not exist.")

