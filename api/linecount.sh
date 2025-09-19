#!/bin/bash
wc -l $(git ls-files | grep '.*\.cs')
