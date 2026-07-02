<template>
  <div
    class="min-h-screen bg-slate-100 flex flex-col items-center justify-center font-sans"
  >
    <h1 class="text-9xl font-bold text-red-500">{{ error.statusCode }}</h1>
    <p class="text-2xl font-semibold text-slate-800 mt-4">
      Ωχ! Κάτι πήγε στραβά.
    </p>
    <p class="text-slate-500 mt-2">{{ error.statusMessage }}</p>

    <button
      @click="handleClearError"
      class="mt-6 bg-slate-50 text-slate-800 font-medium leading-5 rounded-lg px-4 py-2.5 border shadow-md"
    >
      Επιστροφή στην Αρχική
    </button>
  </div>
</template>

<script setup>
defineProps({
  error: Object,
});

const handleClearError = () => clearError({ redirect: '/leavetypes' });
</script>
