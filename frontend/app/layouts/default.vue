<template>
  <div class="min-h-screen font-sans flex flex-col">
    <header class="bg-slate-800 text-white p-4">
      <div class="container mx-auto flex justify-between items-center">
        <h1 class="text-xl font-bold">Leave Management</h1>
        <nav class="space-x-4">
          <NuxtLink to="/leavetypes">Λίστα Αδειών</NuxtLink>
          <NuxtLink
            to="/leavetypes/create"
            class="bg-slate-50 text-slate-800 font-medium leading-5 rounded-lg text-sm px-4 py-2.5"
            >Νέα Άδεια</NuxtLink
          >
        </nav>
      </div>
    </header>

    <main class="flex-grow container mx-auto py-6">
      <slot />
    </main>

    <footer class="bg-slate-800 text-white text-center p-4 text-sm">
      &copy; 2026 - Leave Management System
    </footer>
  </div>
</template>
