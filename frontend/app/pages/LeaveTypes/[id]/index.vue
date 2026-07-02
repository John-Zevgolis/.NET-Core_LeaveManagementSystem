<template>
  <div v-if="leaveType">
    <h1>Leave Type Details for {{ leaveType.name }}</h1>
    <hr />
    <div>Name {{ leaveType.name }}</div>
    <div>Maximum Allocation of Days {{ leaveType.numberOfDays }}</div>
  </div>
</template>

<script setup>
const config = useRuntimeConfig();
const route = useRoute();

const {
  data: leaveType,
  error,
  pending,
} = await useFetch(`${config.public.apiBase}/leavetypes/${route.params.id}`);

if (error.value) {
  throw createError({
    statusCode: 404,
    statusMessage: error.value.message,
  });
}

useHead({
  title: () => `${leaveType.value.name} Details`,
});
</script>

<style lang="scss" scoped></style>
