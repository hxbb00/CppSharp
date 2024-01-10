#!/bin/bash

./build/build.sh clean
./build/build.sh generate -platform x64
./build/build.sh restore -platform x64
./build/build.sh -build_only -platform x64