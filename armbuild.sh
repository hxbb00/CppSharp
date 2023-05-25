#!/usr/bin/env bash

./build/build.sh clean
./build/build.sh generate -platform aarch64
./build/build.sh restore -platform aarch64
./build/build.sh -build_only -platform aarch64