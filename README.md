# Visual Studio Local LLM Plugin - With Ollama - Extra Tool

## Project Objective: 
To get help from Local AI quickly on Visual Studio. Thanks to Local LLM, to ensure project security and prevent code leaks. At the same time, to make a tool that provides convenience in terms of certain functions.

## How does it work?

While working on Visual Studio. you can use the tools you want by opening the tool with the key combination you will assign. You can get help from artificial intelligence by writing a message. You can send the codes you choose to the artificial intelligence with a single button and have it work on those codes. 

## Assignment Process:
Visual Studio - Tools - Keyboard - Whow Commands Containing LocalLLLMPlug

## Supported Servers.
OLLAMA

## Ollama Install

Download: https://ollama.com/download
Model: https://ollama.com/search

After installing and running the Ollama server, you can download and run the model you want. Then you can select and save your server settings and model from the Plugin settings section. 

ollama run deepseek-r1:1.5b

## Supported Models:
deeepseek-r1
llama3.3
phi4
nomic-embed-text
mistral
qwen
gemma
llava
qwen2.5-code
mxbai-embed-large
starcoder2

## Extra Features:

### Remove Duplicate: 

It removes all duplicate lines in the code section you have selected and quickly edits your code.

### Modify & Replicate:

It reproduces your code by selecting a specific code and replacing the words you will write in the prompt section with the word you have selected.

For example:

Selected Text
Console.WriteLine(‘Hello’);

Prompt:
Dobis
Hedwis
Arpis

Word: Hello

Conclusion:
Console.WriteLine(‘Dobis’);
Console.WriteLine(‘Hedwis’);
Console.WriteLine(‘Arpis’);

## Erase

It edits the word or sentence you will write by deleting it from the front or back of the code block you have selected.

## Add

It edits the word or sentence you will write by adding it from the front or back of the code block you have selected.


