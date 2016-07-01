// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#pragma once

#if !defined(STANDALONE)
#include "pal_types.h"
#else
#include "standalone_config.h"
#endif

extern "C" int32_t SystemNative_GetNodeName(char* version, int* capacity);
