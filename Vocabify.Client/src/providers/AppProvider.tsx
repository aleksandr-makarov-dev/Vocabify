import { queryClient } from "@/lib/react-query";
import { QueryClientProvider } from "@tanstack/react-query";
import React from "react";
import { FC, PropsWithChildren } from "react";
import AudioProvider from "./AudioProvider";

export const AppProvider: FC<PropsWithChildren<{}>> = ({ children }) => {
  return (
    <React.Suspense
      fallback={
        <div className="h-screen flex items-center justify-center">
          <div className="text-center">
            <h5 className="font-semibold text-lg">Please wait for a while</h5>
            <p className="text-gray-700">Loading page...</p>
          </div>
        </div>
      }
    >
      <QueryClientProvider client={queryClient}>
        <AudioProvider>{children}</AudioProvider>
      </QueryClientProvider>
    </React.Suspense>
  );
};
